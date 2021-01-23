private async void button1_Click(object sender, EventArgs e)
{
    Debug.Write("Running click event");
    this.button1.Click -= button1_Click;
    await Task.Run(() => Task.Delay(5000));
    this.button1.Click += button1_Click;
}
