        using System;
        using System.Threading.Tasks;
        namespace RefreshTest {
            public delegate void RefreshCallback();
            public class RefreshInterval {
                private readonly object _syncRoot = new Object();
                private readonly long _interval;
                private long _lastRefresh;
                private bool _updating;
                public event RefreshCallback RefreshData = () => { };
                public RefreshInterval(long interval) {
                    _interval = interval;
                }
                public void Refresh() {
                    if (Environment.TickCount - _lastRefresh < _interval || _updating) {
                        return;
                    }
                    lock (_syncRoot) {
                        if (Environment.TickCount - _lastRefresh < _interval || _updating) {
                            return;
                        }
                        _updating = true;
                        Task.Run(() => LoadData());
                    }
                }
                private void LoadData() {
                    try {
                        RefreshData();
                        _lastRefresh = Environment.TickCount;
                    }
                    catch (Exception e) {
                        //handle appropriately
                    }
                    finally {
                        _updating = false;
                    }
                }
            }
        }
