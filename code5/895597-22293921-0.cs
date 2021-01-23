    class PredicateResult{
        public En_LineType type;
        public String data;
    }
    private PredicateResult FirstReader(String line){
        if(line.StartsWith("HELLO")){
            return new PredicateResult{
                type = En_LineType.Hello,
                data = ...
            }
        }
    }
