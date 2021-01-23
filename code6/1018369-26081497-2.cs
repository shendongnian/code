        public class SpeechAlternative
        {
            public string Transcript { get; set; }
            public double Confidence { get; set; }
        }
        public class SpeechResult
        {
            public SpeechAlternative[] Alternative { get; set; }
            public bool Final { get; set; }
        }
        public class SpeechResponse
        {
            public SpeechResult[] Result { get; set; }
            public int Result_Index { get; set; }
        }
