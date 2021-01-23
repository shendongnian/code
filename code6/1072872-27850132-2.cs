    namespace UltraFeederControl
    {
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public static class GestioneSetupFiles
    {
    	private const short TAB_POS = 30;
    	static string Testo;
    	static string Paragrafo;
    
    	static int PtrParagrafo;
    	public static string DEFAULT_APP_DIR = My.Application.Info.DirectoryPath;
    	//Public DEFAULT_APP_DIR As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\BTSR\PC-LINK NEMO"
    
    
    	public static string DEFAULT_CONFIG_DIR = DEFAULT_APP_DIR + "\\Config";
    	public static void CheckConfigDir()
    	{
    		//Verifica la presenza della cartella Config
    		//Se non esiste la crea e per compatibilità con le versioni precedenti ci copia dentro tutti i files .cfg e .dat che trova
    		if (!My.Computer.FileSystem.DirectoryExists(DEFAULT_CONFIG_DIR)) 
            {
    			//Dim NomeFile As String
    			My.Computer.FileSystem.CreateDirectory(DEFAULT_CONFIG_DIR);
    			//NomeFile = Dir(DEFAULT_APP_DIR + "\*.cfg")
    			//While NomeFile <> ""
    			//    'My.Computer.FileSystem.MoveFile(DEFAULT_APP_DIR + "\" + NomeFile, DEFAULT_CONFIG_DIR + "\" + NomeFile)
    			//    'per compatibilità con vecchio (se reinstallato) non sposta ma copia i file
    			//    My.Computer.FileSystem.CopyFile(DEFAULT_APP_DIR + "\" + NomeFile, DEFAULT_CONFIG_DIR + "\" + NomeFile)
    			//    NomeFile = Dir()
    			//End While
    			//NomeFile = Dir(DEFAULT_APP_DIR + "\*.dat")
    			//While NomeFile <> ""
    			//    'My.Computer.FileSystem.MoveFile(DEFAULT_APP_DIR + "\" + NomeFile, DEFAULT_CONFIG_DIR + "\" + NomeFile)
    			//    'per compatibilità con vecchio (se reinstallato) non sposta ma copia i file
    			//    My.Computer.FileSystem.CopyFile(DEFAULT_APP_DIR + "\" + NomeFile, DEFAULT_CONFIG_DIR + "\" + NomeFile)
    			//    NomeFile = Dir()
    			//End While
    		}
    	}
    }
    
    }
