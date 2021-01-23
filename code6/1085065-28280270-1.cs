    private void MarkRowAsDone(object sender, MouseButtonEventArgs e)
        {
            using (var context = new Context())
            {
                try
                {
                    //If you have set a ID, get that ID to do a "select"-statement
                    var row = context.CLASS.Find(selectedItem.Id);
                    row.Done = true;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
