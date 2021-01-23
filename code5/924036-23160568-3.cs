    public int PerformRepeatLogic(int x)
    {
        //Mods a pixel position to fit in a chunk texture
            int result = Math.Abs(x) % 1024;
            if (x < 0)
            {
                result = 1024 - result;
                if (result == 1024)
                    result = 0;
            }
            return result;
    }
