    /// <summary>
    /// Save the displayed option's checked items then load the Fruit options to the CheckedListBox.
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">EventArgs</param>
    private void FruitButton_Click(object sender, EventArgs e)
    {
      this.SaveCheckedStates();
      this.LoadOptions(0);
    }
    /// <summary>
    /// Save the displayed option's checked items then load the Meat options to the CheckedListBox.
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">EventArgs</param>
    private void MeatButton_Click(object sender, EventArgs e)
    {
      this.SaveCheckedStates();
      this.LoadOptions(1);
    }
    /// <summary>
    /// Save the displayed option's checked items then load the Drink options to the CheckedListBox.
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">EventArgs</param>
    private void DrinksButton_Click(object sender, EventArgs e)
    {
      this.SaveCheckedStates();
      this.LoadOptions(2);
    }
    /// <summary>
    /// Add an item to the currently displayed Option's items.
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">EventArgs</param>
    private void AddButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.textBox1.Text) && this.SourceIndex >= 0)
      {
        int index = this.Options[this.SourceIndex].Count;
        string text = this.textBox1.Text;
        this.Options[this.SourceIndex].Add(index, text);
        this.SaveCheckedStates();
        this.LoadOptions(this.SourceIndex);
      }
    }
