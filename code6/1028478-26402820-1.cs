    public class QuestionTemplateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string MathML { get; set; }
        public string Expression { get; set; }
        public string QType { get; set; }
        public Dictionary<string, VariableDetails> Rules = new Dictionary<string, VariableDetails>() { get; set; }
    
    }
    
 
    
    public class VariableDetails
    {
        public string variableType { get; set; }
        public string min { get; set; }
        public string max { get; set; }
    }
