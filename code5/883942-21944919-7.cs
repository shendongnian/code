    using System.Collections.Generic;
    namespace RefreshTest {
        internal static class ContextCache {
            private static readonly RefreshInterval _refresher = new RefreshInterval(60000);
            private static List<int> _customerTypes = new List<int>();
            static ContextCache() {
                _refresher.RefreshData += RefreshData;
            }
            internal static List<int> CustomerTypes {
                get {
                    _refresher.Refresh();
                    return _customerTypes;
                }
            }
            private static void RefreshData() {
                List<int> customerTypes = new List<int>();  //dbContext.GetCustomerTypes();
                Interlocked.Exchange(ref _customerTypes, customerTypes);
            }
        }
    }
