        private void objlv_CellEditStarting(object sender, CellEditEventArgs e)
        {
            //e.Column.AspectName gives the model column name of the editing column
            if (e.Column.AspectName == "DoubleValue")
            {
                NumericUpDown nud = new NumericUpDown();
                nud.MinValue = 0.0;
                nud.MaxValue = 1000.0;
                nud.Value = (double)e.Value;
                e.Control = nud;
            }
        }
