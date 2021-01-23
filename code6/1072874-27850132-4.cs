    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    namespace GestioneSetupFile
    {
    	public static class GestioneSetupFiles
    	{
    		private const short TAB_POS = 30;
    		static string Testo;
    		static string Paragrafo;
    
    		static int PtrParagrafo;
    		public static string DEFAULT_APP_DIR = My.Application.Info.DirectoryPath;
    
    		public static string DEFAULT_APP_DIR = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\BTSR\\PC-LINK NEMO";
    
    		public static string DEFAULT_CONFIG_DIR = DEFAULT_APP_DIR + "\\Config";
    		public static void CheckConfigDir()
    		{
    
    			if (!My.Computer.FileSystem.DirectoryExists(DEFAULT_CONFIG_DIR)) 
                {
    				string NomeFile = null;
    				My.Computer.FileSystem.CreateDirectory(DEFAULT_CONFIG_DIR);
    				NomeFile = FileSystem.Dir(DEFAULT_APP_DIR + "\\*.cfg");
    				while (!string.IsNullOrEmpty(NomeFile)) 
                    {
    					My.Computer.FileSystem.MoveFile(DEFAULT_APP_DIR + "\\" + NomeFile, DEFAULT_CONFIG_DIR + "\\" + NomeFile);
    					My.Computer.FileSystem.CopyFile(DEFAULT_APP_DIR + "\\" + NomeFile, DEFAULT_CONFIG_DIR + "\\" + NomeFile);
    					NomeFile = FileSystem.Dir();
    				}
    				NomeFile = FileSystem.Dir(DEFAULT_APP_DIR + "\\*.dat");
    				while (!string.IsNullOrEmpty(NomeFile)) 
                    {
    					My.Computer.FileSystem.MoveFile(DEFAULT_APP_DIR + "\\" + NomeFile, DEFAULT_CONFIG_DIR + "\\" + NomeFile);
    					My.Computer.FileSystem.CopyFile(DEFAULT_APP_DIR + "\\" + NomeFile, DEFAULT_CONFIG_DIR + "\\" + NomeFile);
    					NomeFile = FileSystem.Dir();
    				}
    			}
    		}
    	}
    }
