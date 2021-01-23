    private string _metaScore;
    [JsonProperty(PropertyName = "Metascore")]
    public String Metascore { 
    get { return _metaScore; } 
    set { _metaScore = value; 
          int result;
          if(int.TryParse(_metaScore, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result))
           MetaScoreInt = result;
        }
    }
    
    [Column("metascore")]
    public int MetascoreInt
    {
        get;set;
    }
