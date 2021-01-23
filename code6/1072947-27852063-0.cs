    private void button3_Click(object sender, EventArgs e)
    {  
        //Default the pictures first
        pictureBox1.Image = list1[0];//Verify that this exists as well
        pictureBox2.Image = list1[1];//Verify that this exists as well
        if(timeNum <= 1){
            MessageBox.Show(“oHs Noes!!!!!!”);
        }
        else{
            for (int index = 1; index < timeNum; index++)
            {
                Thread.Sleep(5000);  
                pictureBox1.Image = list1[index * 2]; //You will need to verify that this exists as well
                pictureBox2.Image = list1[index * 2 + 1];//You will need to verify that this exists as well
            }
        }
    }
