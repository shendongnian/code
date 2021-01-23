 	using System;
	using System.Collections.Generic;
	using System.Data;
	using Breeze.ContextProvider;
	using Newtonsoft.Json.Linq;
	
    public class SaveBundleToSaveMap : ContextProvider 
    {
        // Never create a public instance
        private SaveBundleToSaveMap(){}
        /// <summary>
        /// Convert a saveBundle into a SaveMap
        /// </summary>
        public static Dictionary<Type, List<EntityInfo>> Convert(JObject saveBundle)
        {
            var dynSaveBundle = (dynamic) saveBundle;
            var entitiesArray = (JArray) dynSaveBundle.entities;
            var provider = new SaveBundleToSaveMap();
            var saveWorkState = new SaveWorkState(provider, entitiesArray);
            return saveWorkState.SaveMap;
        }
        // override abstract members but DO NOT USE ANY OF THEM
    }
