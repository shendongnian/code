    public Stream test(string ot) {
        ot = ot ?? "XML";
        try {
            OutputType kind = Enum.Parse(typeof(OutputType), ot);
            . . . 
        }catch(ArgumentException e) }
           . . .
        }
    }
