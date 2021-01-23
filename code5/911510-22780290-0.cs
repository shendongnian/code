    var boxes = new RichTextBox[...]
    boxes[0] = richTextBox1.Visible;
    ...
    for (int y = 0; y < boxes.Lengthl y++) {
      boxes[y].Visible = false;
    }
