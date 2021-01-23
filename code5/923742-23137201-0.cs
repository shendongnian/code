    private int operationState = 0; 
    private void timer1_Tick(object sender, EventArgs e)
    {
        switch(operationState)
        {
            case 0://Next image
            {
                pictureBox1.ImageLocation = picture[index];
                pictureBox2.ImageLocation = picture[index + 1];
        
                index++;
                if (index >= (picture.Length - 1))
                {
                    index = 0;
                }
                break;
            }
            case 1://Swap
            {
                string tempLocation =  pictureBox1.ImageLocation;
                pictureBox1.ImageLocation = pictureBox2.ImageLocation;
                pictureBox2.ImageLocation = tempLocation;
                break;
            }
        }
        
        operationState = (++operationState) % 2;
    }
