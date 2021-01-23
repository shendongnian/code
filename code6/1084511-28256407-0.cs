        if (b == 1)
        {
            pictureBox4.BackgroundImage = MyProject.Properties.Resources._2;
            b = 2;
        }
        if (b == 2)
        {   /* This is using the same property name as above, so it won't switch the images the second time. */
            /* Did you mean to use Resources._1 here? */
            pictureBox4.BackgroundImage = MyProject.Properties.Resources._2;
            b = 1;
        }
