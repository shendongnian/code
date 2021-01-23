    public void Draw(int width){
        int w_counter = 1;
    
        for (int l = 0; l < 6; l++) {
             var asterisk = new String('*', w_counter);
             var hash = new String('#', width - w_counter);
             Console.WrilteLine(asterisk + hash);
             w_counter++;
        }
    }
