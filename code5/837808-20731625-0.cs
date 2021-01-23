    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    
    namespace WpfApplication
    {
        class MainWindowModel : INotifyPropertyChanged
        {
            private DataTable numbersTable;
            private Predicate<int> highlightCriteria;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public DataTable NumbersTable
            {
                get { return this.numbersTable; }
                set { this.SetValue(ref this.numbersTable, value, "NumbersTable"); }
            }
    
            public Predicate<int> HighlightCriteria
            {
                get { return this.highlightCriteria; }
                set { this.SetValue(ref this.highlightCriteria, value, "HighlightCriteria"); }
            }
    
            public MainWindowModel()
            {
                this.NumbersTable = new DataTable("Numbers")
                {
                    Columns = 
                    {
                        { "Number", typeof(int) }
                    },
                };
    
                for (int i = 1; i < 91; i++)
                    this.NumbersTable.Rows.Add(i);
    
                // By default only numbers larger than 10 and lower than 50 will be highlighted.
                this.HighlightCriteria = num => num > 10 && num < 50;
            }
    
            protected void SetValue<T>(ref T field, T value, string propertyName)
            {
                if (!EqualityComparer<T>.Default.Equals(field, value))
                {
                    field = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
                }
            }
    
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                    handler(this, e);
            }
        }
    }
