    public class TextFieldParser
        {
            enum FieldType { FixedWidth, Delimited };
            
            public enum CompleteElements 
            {
                /// <summary>
                /// Returns as many elements as fileWidths input be
                /// </summary>
                AllElements, 
                /// <summary>
                /// Only returns elements who have not null values
                /// </summary>
                OnlyValues 
            };
    
            int[] m_fieldWidths;
            string m_line;
            List<string> m_results;
            int m_lineWidth;
            public CompleteElements m_CompleteElements;
    
            public TextFieldParser(string line)
            {
                m_line = line;
                m_lineWidth = m_line.Length;
                m_results = new List<string>();
                m_CompleteElements = CompleteElements.OnlyValues;
            }
    
            public void SetCompleteElements(CompleteElements value) 
            {
                m_CompleteElements = value;
            }
    
            public void SetFieldWidths(params int[] fileWidths)
            {
                m_fieldWidths = fileWidths;
            }
    
            public string[] ReadFields()
            {
                int pivot = 0;
                m_results = new List<string>();
    
                for (int x = 0; x < m_fieldWidths.Length; x++) 
                {
                    if(pivot + m_fieldWidths[x] <= m_lineWidth)
                    {
                        m_results.Add(m_line.Substring(pivot, m_fieldWidths[x]));                    
                    }
                    else
                    {
                        if (m_CompleteElements == CompleteElements.AllElements) 
                        {
                            m_results.Add(null);
                        }
                        
                        break;
                    }
                    pivot += m_fieldWidths[x];
                }
                return m_results.ToArray();
            }
        }
