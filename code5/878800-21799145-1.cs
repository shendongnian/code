    private void button5_Click(object sender, EventArgs e)
    {
         Button[] button = { button1, button2, button3, button4 };
         for (int i = 0; i < m_game.TheArray.Length; i++)
         {
             button[m_game.TheArray[i]].PerformClick();
         }
    }
