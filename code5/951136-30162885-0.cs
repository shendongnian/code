    using System;
    using System.Configuration;
    using Elasticsearch.Net;
    using Elasticsearch;
    using Elasticsearch.Net.Connection;
    using Elasticsearch.Net.ConnectionPool;
    
    namespace Common {
    	
    	/// <summary>
    	/// Elastic search. Singletone, open connection and thread safe to be open for all the time
    	/// the app is running, so we send ours logs to ealsticsearch to be analyzed, assychronly
    	/// See the fourth version;
    	/// http://csharpindepth.com/articles/general/singleton.aspx
    	/// </summary>
    	public sealed class ElasticSearch {
    		// our instance of ourself as a singleton
    		private static readonly ElasticSearch instance = new ElasticSearch();
    		
    		ElasticsearchClient client;
    		string connectionString = ConfigurationManager.ConnectionStrings["Elasticsearch"].ConnectionString;
    		
    		/// <summary>
    		/// Initializes a new instance of the <see cref="Common.ElasticSearch"/> class.
    		/// Follow this: http://nest.azurewebsites.net/elasticsearch-net/connecting.html
    		/// We use a ConnectionPool to make the connection fail-over, that means, if the 
    		/// connection breaks, it reconnects automatically
    		/// </summary>
    		private	ElasticSearch() {
    			var node = new Uri(connectionString);
    			var connectionPool = new SniffingConnectionPool(new[] { node });
    			var config = new ConnectionConfiguration(connectionPool);
    			client = new ElasticsearchClient(config);   // exposed in this class
    		}
    		
    		static ElasticSearch() {
    		}
    		
    		/// <summary>
    		/// Gets the instance of our singleton class
    		/// </summary>
    		/// <value>The instance.</value>
    		public static ElasticSearch Instance {
    			get {
    				return instance;
    			}
    		}
    	
    		/// <summary>
    		/// Log the specified module, id and json.
    		/// </summary>
    		/// <param name="type">Here the entity you want to save your log,
    		/// let's use it based on classes and StateMachines</param>
    		/// <param name="id">Identifier. alwayes the next</param>
    		/// <param name="json">Json.</param>
    		public void Log(string type, string id, string json) {
    			client.Index("mta_log", type, id, json);
    		}
    			
    	}
    }
