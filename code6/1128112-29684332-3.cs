        private void objlv_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "DoubleValue")
            {
                //Here you can verify data, if the data is wrong, call
                if ((double)e.NewValue > 10000.0)
                    e.Cancel = true;
            }
        }
