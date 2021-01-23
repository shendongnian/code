    private void button_ItemClick(object sender, ItemClickEventArgs e)
            {
                try
                {
                    OpenWin("window2", new Uri(@"window2.xaml", UriKind.Relative), "Window2Label");
                }
                catch (Exception ex)
                {
                    Message.Show(ex);
                }
            }
