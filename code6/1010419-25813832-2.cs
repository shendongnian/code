    private void serialPortOKBtn_Click(object sender, RoutedEventArgs e)
            {
                txt_noSerialSelected.Visibility = Visibility.Hidden;
                if (cmbbox_serialPortList.SelectedItem == null)
                {
                    txt_noSerialSelected.Visibility = Visibility.Visible;
                }
                else
                {
                    _portname = cmbbox_serialPortList.SelectedItem.ToString();
                    textBox.Text = _portname;
                    this.Close();
                }
            }
