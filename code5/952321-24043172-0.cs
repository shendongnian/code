        public void
        CatchColor(Color c)
        {
            if (c IS BlueColor)
                CatchColor(c as BlueColor);
            if (c IS GreenColor)
                CatchColor(c as GreenColor);
        }
?
