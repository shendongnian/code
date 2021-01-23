    public void removeMonster(GameObject gameObject){
            print (gameObject);
            GameObject objToRemove = allMonsters.DefaultIfEmpty(null)
                                        .FirstOrDefault(f=>f.obj.ID=gameObject.ID);
            if (objToRemove!=null)
                aliveMonsters.Remove(objToRemove);
            else
                throw new Exception("That monster isn't in the list.")
        }
