    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestNamespace
    {
        class ILOrderTest
        {
            public int DeclarationTests()
            {
                int intDeclaredAtTop = 0;
    
                for (int intDeclaredInForLoopDef = 0; intDeclaredInForLoopDef < 10; intDeclaredInForLoopDef++)
                {
                    int intDeclaredInForLoopBody = intDeclaredInForLoopDef;
                    intDeclaredAtTop = intDeclaredInForLoopBody;
                }
                int intDeclaredAfterForLoop;
                intDeclaredAfterForLoop = intDeclaredAtTop;
                return intDeclaredAfterForLoop;
            }
        }
    }
