 	using System;
	using System.Collections.Generic;
	using System.Data;
	using Breeze.ContextProvider;
	using Newtonsoft.Json.Linq;
	
    public class SaveBundleToSaveMap : ContextProvider 
    {
        private static readonly SaveBundleToSaveMap _provider  = new SaveBundleToSaveMap();
        // Never create a public instance
        private SaveBundleToSaveMap(){}
        /// <summary>
        /// Convert a saveBundle into a SaveMap
        /// </summary>
        public static Dictionary<Type, List<EntityInfo>> Convert(JObject saveBundle, TransactionSettings transactionSettings = null)
        {
            var dynSaveBundle = (dynamic) saveBundle;
            var entitiesArray = (JArray) dynSaveBundle.entities;
            var saveWorkState = new SaveWorkState(_provider, entitiesArray);
            return saveWorkState.SaveMap;
        }
        // override abstract members but DO NOT USE ANY OF THEM
    }
