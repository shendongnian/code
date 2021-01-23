        void Cust_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "RecordState")
            {
                if (Cust.RecordState == RecordState.Unchanged)
                    Cust.RecordState = RecordState.Modified;
            }
        }
