        public Boolean GetVisibleObject<T>(UInt32 objId, out T obj) 
            where T : WorldObject
        {
              //I need to be able to search all 3 dictionaries with this function.
              //It should use "objId" to search for an existing key in either of the 3.
            obj = null;
            if (typeof(T) == typeof(Character))
            {
                if (_currentVisibleCharacters.ContainsKey(objId))
                {
                    obj = _currentVisibleCharacters[objId] as T;
                    return true;
                }
            }
            else if (typeof(T) == typeof(Item))
            {
                if (_currentVisibleMapItems.ContainsKey(objId))
                {
                    obj = _currentVisibleMapItems[objId] as T;
                    return true;
                }
            }
            else if (typeof(T) == typeof(Npc))
            {
                if (_currentVisibleNpcs.ContainsKey(objId))
                {
                    obj = _currentVisibleNpcs[objId] as T;
                    return true;
                }
            }           
            return false;
        }
