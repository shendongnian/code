    private async void TxtLotTextLeave(object sender, EventArgs e)
    {
        if (yourButton.IsInMouseDown)
        {
            Console.WriteLine("Ignoring Leave");
            return;
        }
        ...
    }
