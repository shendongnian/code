    public void SaveCVInfo3(int columnaId, string varOne, string varTwo, string varThree, string varFour, string varFive, string varSix, string varSeven,
        string varEight, string varNine, string varTen, string varEleven, string varTwelve, string varThirteen, string varFourteen, string varFifteen)
    {
    	using (ConexionGeneralDataContext db = new ConexionGeneralDataContext())
    	{
    		//You will need to add reference to Linq if not added already
    		//Usuario_Web columna = new Usuario_Web();
    		//Insert the new Customer object
    		
    		Usuario_Web columna = (Usuario_Web)db.Usuario_Webs.Find(columnaId);
    		columna.Estatus = 1;
    		columna.nombre_esposo = varOne;
    		columna.profe_compa = varTwo;
    		columna.emp_compa = varThree;
    		columna.cargo_actual_compa = varFour;
    		columna.Hijos = varFive;
    		columna.Edades_hijos = varSix;
    		columna.persona_depende_compa = varSeven;
    		columna.afinidades = varEight;
    		columna.Edades_depende = varNine;
    		columna.nom_padre = varTen;
    		columna.profesion_padre = varEleven;
    		columna.tel_padre = varTwelve;
    		columna.nom_madre = varThirteen;
    		columna.profesion_madre = varFourteen;
    		columna.tel_madre = varFifteen;
    
    		//db.Usuario_Web.InsertOnSubmit(columna);
    		//Sumbit changes to the database
    		db.SubmitChanges();
    	}
    }
