    /// <summary>
        /// Handles the client result string.
        /// </summary>
        /// <param name="downloadedString">The downloaded string.</param>
        public TResultType ConvertClientResultString(string downloadedString)
        {
            // Check for html doctype and report error if found.
            int takeLength = downloadedString.Length > 20 ? 20 : downloadedString.Length;
            if (downloadedString.Substring(0, takeLength).Contains("!DOCTYPE html"))
                HandleClientError(new NotSupportedException("The service call returned html and not json"));
            var result = new TResultType();
            string json = downloadedString;
            if (result is IJSONMassager)
            {
                json = ((IJSONMassager)result).MassageJSON(downloadedString);
            }
            if (result is IJSONSelfSerialize<TResultType>)
            {
                result = ((IJSONSelfSerialize<TResultType>)result).SelfSerialize(json);
            }
            else
                result = JsonHelper.Deserialize<TResultType>(json);
            if (GotResult != null)
                GotResult(this, new EventArgs<TResultType>() { Argument = result });
            return result;
        }
