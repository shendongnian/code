    public static void just_create_text()
    {
        //Here we are exporting header
        string[] strLines = System.IO.File.ReadAllLines(textBox1.Text);
        string defaultCarouselName = enter.Text;
        int[] columnPaddings = new int[] { 15, 15, 25, 15, 15 };
        StringBuilder completedOutputBuilder = new StringBuilder();
        string line = RemoveWhiteSpace(strLines[0]).Trim();
        string[] cells = line.Replace("\"", "").Split('\t');
        for (int c = 0; c < cells.Length; c++)
            completedOutputBuilder.Append(cells[c].Replace(" ", "_").PadRight(columnPaddings[c]));
        completedOutputBuilder.AppendLine("Location".PadRight(15));
        completedOutputBuilder.AppendLine();
        int carouselNumberForEntry = 0;
        Dictionary<string, int> maxPnToCarouselNumber = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < _textfile.Count; i++)
        {
            for (int c = 0; c < cells.Length; c++)
                completedOutputBuilder.Append(_textfile[i].Cells[c].Replace(" ", "_").PadRight(columnPaddings[c]));
            string maxPnForEntry = _textfile[i].Cells[1];
            int previouslyAllocatedCarouselNumberForMaxPn = 0;
            if (maxPnToCarouselNumber.TryGetValue(maxPnForEntry, out previouslyAllocatedCarouselNumberForMaxPn) == false)
            {
                // assign a new courousel number for this max pn
                carouselNumberForEntry++;
                if (carouselNumberForEntry > 45)
                    carouselNumberForEntry = 1;
                // for better clarity use add
                maxPnToCarouselNumber.Add(maxPnForEntry, carouselNumberForEntry);
            }
            else
            {                    
                // use the carousel number previous assigned for this maxPn
                carouselNumberForEntry = previouslyAllocatedCarouselNumberForMaxPn;
            }
            // find the related max pn carousel entry (if relatedPn is not found this suggests a problem elsewhere)
            MAX_PN_Carousel relatedPn = lstMx.Find(x => x.MAX_PN != null && x.MAX_PN.Equals(maxPnForEntry, StringComparison.OrdinalIgnoreCase));
            // assign the name from the entry, or use the default carousel name if unavailable
            string carouselNameForMaxPn = (relatedPn == null || String.IsNullOrWhiteSpace(relatedPn.Carousel)) ? defaultCarouselName : relatedPn.Carousel;
            // add the new column in the output
            completedOutputBuilder.Append(String.Format("{0}:{1}", carouselNameForMaxPn, carouselNumberForEntry).PadRight(15));
            completedOutputBuilder.Append("\r\n");
        }
        System.IO.File.WriteAllText(@"c:\dev\output.TXT", completedOutputBuilder.ToString());
    }
