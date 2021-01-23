    public Stream test(string ot) {
        try {
            OutputType kind = Enum.Parse(typeof(OutputType), ot);
            . . . 
        }catch(ArgumentException e) }
           . . .
        }
    }
