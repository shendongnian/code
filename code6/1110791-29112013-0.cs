    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using TestSO.model;
    namespace TestSO.viewmodel
    {
        public class ScreenViewModel : INotifyPropertyChanged, IDisposable
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private IList<Cell> cells;
            public IList<Cell> Cells
            {
                get
                {
                    return cells;
                }
                set
                {
                    if (object.Equals(cells, value))
                    {
                        return;
                    }
                    UnregisterSource(cells);
                    cells = value;
                    RegisterSource(cells);
                    RaisePropertyChanged("Cells");
                }
            }
            private int rows;
            public int Rows
            {
                get
                {
                    return rows;
                }
                set
                {
                    if (rows == value)
                    {
                        return;
                    }
                    rows = value;
                    RaisePropertyChanged("Rows");
                }
            }
            private int columns;
            public int Columns
            {
                get
                {
                    return columns;
                }
                set
                {
                    if (columns == value)
                    {
                        return;
                    }
                    columns = value;
                    RaisePropertyChanged("Columns");
                }
            }
            private Cell[,] array;
            public Cell[,] Array
            {
                get
                {
                    return array;
                }
                protected set
                {
                    array = value;
                }
            }
            protected void RaisePropertyChanged(string propertyName)
            {
                var local = PropertyChanged;
                if (local != null)
                {
                    App.Current.Dispatcher.BeginInvoke(local, this, new PropertyChangedEventArgs(propertyName));
                }
            }
            protected void RegisterSource(IList<Cell> collection)
            {
                if (collection == null)
                {
                    return;
                }
                var colc = collection as INotifyCollectionChanged;
                if (colc != null)
                {
                    colc.CollectionChanged += OnCellCollectionChanged;
                }
                OnCellCollectionChanged(collection, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, collection, null));
            }
            protected virtual void OnCellCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    Array = null;
                }
                if (e.OldItems != null)
                {
                    foreach (var item in e.OldItems)
                    {
                        var cell = item as Cell;
                        if (cell == null)
                        {
                            continue;
                        }
                        if (Array == null)
                        {
                            continue;
                        }
                        Array[cell.X, cell.Y] = null;
                    }
                }
                if (e.NewItems != null)
                {
                    if (Array == null)
                    {
                        Array = new Cell[Rows, Columns];
                    }
                    foreach (var item in e.NewItems)
                    {
                        var cell = item as Cell;
                        if (cell == null)
                        {
                            continue;
                        }
                        if (Array == null)
                        {
                            continue;
                        }
                        Array[cell.X, cell.Y] = cell;
                    }
                }
            }
            protected void UnregisterSource(IList<Cell> collection)
            {
                if (collection == null)
                {
                    return;
                }
                var colc = collection as INotifyCollectionChanged;
                if (colc != null)
                {
                    colc.CollectionChanged -= OnCellCollectionChanged;
                }
                OnCellCollectionChanged(collection, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
            public ScreenViewModel()
            {
            }
            public ScreenViewModel(int row, int col)
                : this()
            {
                this.Rows = row;
                this.Columns = col;
            }
            bool isDisposed = false;
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (isDisposed)
                    {
                        return;
                    }
                    isDisposed = true;
                    Cells = null;
                }
            }
            public void Dispose()
            {
                Dispose(true);
            }
        }
    }
