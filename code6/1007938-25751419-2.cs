    private async void Starter_Click(object sender, EventArgs e)
    {
            bool res = await Task.Factory.StartNew<bool>(() => { return IsValid(); });
            if (res)
                MessageBox.Show("Showing Window");
    }
    private bool IsValid()
    {
            System.Threading.Thread.Sleep(5000);
            return true;
    }
