    private void button_click(object sender, EventArgs e)
    {    
        string pBoxName = textbox1.Text;
        // I don't quite understand what you mean by 'location number'
        int newPos = int.Parse(textbox2.Text);
        // boxList is a List<PictureBox>
        PictureBox pBox = boxList.Where(x => x.Name.Equals(pBoxName)).FirstOrDefault();
        if(pBox != null)
        {
            MoveTheBox(pBox, newPos);
        }
    }
    private void MoveTheBox(PictureBox box, int newPos)
    {
        // move the box
    }
