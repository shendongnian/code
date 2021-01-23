            string strResultTime = "5 hours";
            //The function that gets the time and converts it to seconds
            MatchEvaluator evaluator = new MatchEvaluator(ConvertToSeconds);
            strResultTime = Regex.Replace(strResultTime, "(?<num>\\d+?) (?<timeUnit>.+)", evaluator);
            //Parse the seconds to an actual datetime.
            DateTime indexTime = DateTime.Now.AddSeconds(int.Parse(strResultTime) * -1);
        /// <summary>
        /// Converts strings if format 'X time' like '2 mins' or '5 hours' to the time that they represents in seconds
        /// </summary>
        /// <param name="mchTime">Match that contains '2 mins' and Groups["timeUnit"] = 'hour' or other time unit AND Groups["num"] = the number of that time unit</param>
        /// <returns>The number of seconds as string</returns>
        private string ConvertToSeconds(Match mchTime)
        {
            //Switch on the time unit
            switch (mchTime.Groups["timeUnit"].Value)
            {
                case "day":
                case "days":
                    //Return the number of days as seconds
                    return (int.Parse(mchTime.Groups["num"].Value) * 24 * 60 * 60).ToString();
                case "hour":
                case "hours":
                    //Return the number of hours as seconds
                    return (int.Parse(mchTime.Groups["num"].Value) * 60 * 60).ToString();
                case "min":
                case "mins":
                    //Return the number of mins as seconds
                    return (int.Parse(mchTime.Groups["num"].Value) * 60).ToString();
                case "sec":
                case "secs":
                    return mchTime.Groups["num"].Value;
                default:
                    throw new NotImplementedException();
            }
        }
