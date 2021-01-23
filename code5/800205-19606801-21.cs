    private void process_DataReceived(object sender, DataReceivedEventArgs e)
    {
        // null data means we've received everything
        if (e.Data == null) {
            process.CancelOutputRead();
            process.CancelErrorRead();
            
            // with WPF:
            mylabel.Dispatcher.Invoke(new Action(() => {
                mylabel.Content = process_output;
            }));
            // with WinForms
            textbox1.Invoke((MethodInvoker) (() =>
            {
                mylabel.Text = process_output;
            }));
            
            return;
        }
        
        // append the output to the accumulator
        process_output += e.Data;
    }
