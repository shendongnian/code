    public class JSONData : JSONNode{
        static Regex m_Regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
        private JSONBinaryTag m_Type = JSONBinaryTag.String;
        private string m_Data;
        public override string Value {
            get { return m_Data; }
            set { m_Data = value; } 
        }
        public JSONData(string aData){
            m_Data = aData;
            // check for number
            if (m_Regex.IsMatch(m_Data))
                m_Type = JSONBinaryTag.Number;
            else
                m_Type = JSONBinaryTag.String;
        }
        [...]
    }
