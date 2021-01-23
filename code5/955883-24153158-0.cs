    using (StreamReader sr = new StreamReader(m_segmentFile.TempFileName))
    using (StreamWriter sw = new StreamWriter(m_segmentFile.DisplayFile))
    {
        //I bet money you meant to use && with != stopped not || with == stopped.
        while ( sr.Peek() >= 0 && m_segmentFile.ParserStatus != ParserStatus.Stopped)
        {
            buffer = new char[m_segmentFile.FieldWidth];
            int offset = 0;
           
            //Keeps reading till the buffer is totally full;
            while(offset < m_segmentFile.FieldWidth && sr.Peek() >= 0 && m_segmentFile.ParserStatus != ParserStatus.Stopped)
            {
                offset += sr.Read(buffer, offset, buffer.Length - offset);
            }
    
           
            //Reads in to the offset we got to, in case we ended early due to the stream ending or being signaled to stop.
            block = new string(buffer, 0, offset);
            if (block[0] != '%')
            {
                noerrors = m_segmentFile.CheckBlockValidity(block) && noerrors;
                int percentComplete = (int)Math.Round((double)(offset * 100) / sr.BaseStream.Length);
                if (percentComplete > m_percentParsed && percentComplete <= 100)
                {
                    m_percentParsed = (int)percentComplete;
                    m_segmentFile.PercentParsed = m_percentParsed;
                }
                block = (m_segmentFile.FieldWidth * index).ToString() + ":" +block;
                sw.WriteLine(block);
                index++;
                m_parserStatus = ParserStatus.Parsing;
            }
            else
            {
                sw.WriteLine(block);
                //sr.BaseStream.Seek();
            }
        }
