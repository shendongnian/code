    for(int i=GenerateManager.Instante.BloquesGenerados.Count - 1; i>=0; i--){
        var gm = GenerateManager.Instante.BloquesGenerados[i];
        if(Vector3.Distance(PlayerManager.Instanse.gameObject.transform.position,gm.transform.position) > 25){ 
            Destroy(gm); 
            GenerateManager.Instante.BloquesGenerados.Remove(gm);
        }
