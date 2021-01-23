    private void StockCodeTextBox_TextChanged(object sender, EventArgs e){
        timer.Stop();
        timer.Start();
        this.Do(f=>{
            if (f.StockCodeTextBox.Text.Equals("")){
                f.AllItemsGridView.ClearSelection();
            }
        }
    }
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e){
        this.Do(f=>{ 
           f.bindingSource.DataSource = logic.GetData(f.StockCodeTextBox.Text);
        }
    }
