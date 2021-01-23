    private Task<TvdbSeries> LoadSeriesAsync(int _seriesId)
    {
    
        return Task.Run(() =>
        {
            TvdbSeries seriesloaded = null;
            try
            {
                seriesloaded = m_tvdbHandler.GetSeries(_seriesId, TvdbLanguage.DefaultLanguage, true, true, true, true);
            }
            catch (TvdbInvalidApiKeyException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (TvdbNotAvailableException ex)
            {
                MessageBox.Show(ex.Message);
            }
    
            return seriesloaded;
        }
         );
    }
