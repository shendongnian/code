        private void salary_texbox_PreviewTextInput ( object sender, TextCompositionEventArgs e )
            {
            Regex regex = new Regex ( "[^0-9]+" );
            if ( regex.IsMatch ( salary_texbox.Text ) )
                {
                MessageBox.Show("Invalid Input !");
                }
            }
