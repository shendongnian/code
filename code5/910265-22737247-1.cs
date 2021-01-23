    var myButtons = this.Controls
        .OfType<Button>()
        .Where(b => b.Tag != null)
        .ToList(); //Because you cannot modify the collection being iterated with for each.
    foreach (Button b in myButtons) {
        b.Click -= new EventHandler(TeamChoiceButton_Click);
        this.Controls.Remove(b);
        b.Dispose();
    }
