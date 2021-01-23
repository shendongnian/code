    var textBoxesList = new Dictionary<MyKey, TextBox>();
    var rowCount = 6;
    var colCount = 3;
    
    for (int row = 0; row < rowCount; row++)
    {
        for (int col = 0; col < colCount; col++)
        {
            var key = new MyKey(row, col);
            var textBox = new TextBox();
    
            textBox.Size = new Size(35, 20);
            textBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            textBox.Location = new System.Drawing.Point(90 + row * 50, 50 + col * 30);
            textBox.Parent = this;
            // store the key in the Tag property of the TextBox
            // so you can get the row and the column of your textbox with
            // var key = (MyKey) textBox.Tag
            textBox.Tag = key; 
    
            textBoxesList.Add(key, textBox);
    
            this.Controls.Add(textBox);
        }
    }
