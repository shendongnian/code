        var st = new Style();
        st.TargetType = typeof(DataGridRow);
        var RedSetter = new Setter( DataGridRow.BackgroundProperty, Brushes.Red);
        var dt = new DataTrigger(){
            Value = CurrentTextToFilter,
            Binding = new Binding("Value")               
        };
        dt.Setters.Add(RedSetter);
        st.Triggers.Add(dt);
        XDG.RowStyle = st;
        PropChanged("MainDataCollection");
 
