         private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = myButton.Tag.ToString();
            txt_conversation.AppendText(Environment.NewLine+text );
        }
