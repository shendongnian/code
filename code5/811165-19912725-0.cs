        public void SaveAs(string filename, bool includeHeaders)
        {
            if (!Path.IsPathRooted(filename) && RuntimeConfig.GetConfig(this._context).HttpRuntime.RequireRootedSaveAsPath)
            {
                object[] objArray = new object[] { filename };
                throw new HttpException(SR.GetString("SaveAs_requires_rooted_path", objArray));
            }
            FileStream fileStream = new FileStream(filename, FileMode.Create);
            try
            {
                if (includeHeaders)
                {
                    TextWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(string.Concat(this.HttpMethod, " ", this.Path));
                    string queryStringText = this.QueryStringText;
                    if (!string.IsNullOrEmpty(queryStringText))
                    {
                        streamWriter.Write(string.Concat("?", queryStringText));
                    }
                    if (this._wr == null)
                    {
                        streamWriter.Write("\r\n");
                    }
                    else
                    {
                        streamWriter.Write(string.Concat(" ", this._wr.GetHttpVersion(), "\r\n"));
                        streamWriter.Write(this.CombineAllHeaders(true));
                    }
                    streamWriter.Write("\r\n");
                    streamWriter.Flush();
                }
                ((HttpInputStream)this.InputStream).WriteTo(fileStream);
                fileStream.Flush();
            }
            finally
            {
                fileStream.Close();
            }
        }
