    namespace Parser
    {
        public class CDBFileParserListener : ICDBFileListener
        {
            public void ExitModule_name(CDBFileParser.Module_nameContext context)
            {
                Console.WriteLine("ModuleName: " + context.GetText());
                // Add module to module-map and remember 
                // that current module is context.GetText()
            }
    
            public void ExitLine_number(CDBFileParser.Line_numberContext context)
            {
                Console.WriteLine("LineNumber: " + context.GetText());
                // Remember line number
            }
    
            public void ExitMemory_address(CDBFileParser.Memory_addressContext context)
            {
                Console.WriteLine("MemoryAddress: " + context.GetText());
                // Add linenumber <-> memoryaddress to maps
            }
            public Modules[] getModules() 
            {
                return m_modules;
            }
        }
        
 
    } 
