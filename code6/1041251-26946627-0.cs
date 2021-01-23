    private void result_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            DataRowView view = result_box.SelectedItem as DataRowView;
            
                if (view != null)
                {                    
                    MessageBox.Show(view["ID"].ToString());
                    Searchbox.Text = view["ID"].ToString();
                } 
                      
        }
