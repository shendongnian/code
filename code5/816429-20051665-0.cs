    public static void redPanel(Panel panel1)
    {
        var mouseEnter = new EventHandler((o, a) => panel1.BackColor = Color.Brown);
        panel1.MouseEnter += mouseEnter;
        pictureBox1.MouseEnter += mouseEnter;
        label1.MouseEnter += mouseEnter;
    
        // And so on
    }
