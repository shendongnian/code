    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace MalApp2
    {
    	public class AnimeI
    	{
    
    		public override string ToString()
    		{
    			return this.Series_Title.ToString();
    		}
    
    		public AnimeI (string series_animedb_id, string series_title, string series_synonyms, string series_type,
    			string series_episodes, string series_status, string series_start, string series_end, string series_image,
    			string my_id, string my_watched_episodes, string my_start_date, string my_finish_date, string my_score,
    			string my_status, string my_rewatching, string my_rewatching_ep, string my_last_updated,
    			string my_tags)
    		{
    			this.Series_Animedb_Id = series_animedb_id;
    			this.Series_Title = series_title;
    			this.Series_Synonyms = series_synonyms;
    			this.Series_Type = series_type;
    			this.Series_Episodes = series_episodes;
    			this.Series_Status = series_status;
    			this.Series_Start = series_start;
    			this.Series_End = series_end;
    			this.Series_Image = series_image;
    			this.My_Id = my_id;
    			this.My_Watched_Episodes = my_watched_episodes;
    			this.My_Start_Date = my_start_date;
    			this.My_Finish_Date = my_finish_date;
    			this.My_Score = my_score;
    			this.My_Status = my_status;
    			this.My_Rewatching = my_rewatching;
    			this.My_Rewatching_Ep = my_rewatching_ep;
    			this.My_Last_Updated = my_last_updated;
    			this.My_Tags = my_tags;
    		}
    		public AnimeI()
    		{
    
    		}
    
    		public string Series_Animedb_Id { get; set; }
    
    		public string Series_Title { get; set; }
    
    		public string Series_Synonyms { get; set; }
    
    		public string Series_Type { get; set; }
    
    		public enum SeriesTypeEnum
    		{
    			Unknown = 0,
    			Tv = 1,
    			Ova = 2,
    			Movie = 3,
    			Special = 4,
    			Ona = 5,
    			Music = 6
    		}
    
    		public string Series_Episodes { get; set; }
    
    		public string Series_Status { get; set; }
    
    		public enum Series_StatusEnum
    		{
    			Watching = 1,
    			Completed = 2,
    			OnHold = 3,
    			Dropped = 4,
    			PlanToWatch = 6
    		}
    
    		public string Series_Start { get; set; }
    
    		public string Series_End { get; set; }
    
    		public string Series_Image { get; set; }
    
    		public string My_Id { get; set; }
    
    		public string My_Watched_Episodes { get; set; }
    
    		public string My_Start_Date { get; set; }
    
    		public string My_Finish_Date { get; set; }
    
    		public string My_Score { get; set; }
    
    		public string My_Status { get; set; }
    
    		public string My_Rewatching { get; set; }
    
    		public string My_Rewatching_Ep { get; set; }
    
    		public string My_Last_Updated { get; set; }
    
    		public string My_Tags { get; set; }
    	}
    }
