     void Update() {
         if(spawned<10){
             position = new Vector3(Random.Range(-9.0F, 9.0F), 10.5f, Random.Range(-9.0F, 9.0F));
             GameObject tmp = Instantiate(Goodfood, position, Quaternion.identity) as GameObject;
             spawned++;
         }
     }
