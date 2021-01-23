    // Provides common functionality for blocks.
    abstract class BlockBase
    {
        protected BlockBase()
        {
            Variables = new List<Variable>();
            Blocks = new List<BlockBase>();
        }
    
        protected BlockBase(XElement xBlock)
            : this()
        {
            // Add variables and blocks.
            foreach (var item in xBlock.Elements())
            {
                AddVariable(Variable.Parse(item));
                AddBlock(IfStatement.Parse(item));
                AddBlock(Addition.Parse(item));
            }
        }
    
        BlockBase Parent { get; set; }
    
        // Block variables.
        public List<Variable> Variables { get; set; }
    
        // Sub-blocks.
        public List<BlockBase> Blocks { get; set; }
    
        // Adds a variable.
        private void AddVariable(Variable variable)
        {
            if (variable != null)
            {
                Variables.Add(variable);
            }
        }
    
        // Adds a block.
        private void AddBlock(BlockBase block)
        {
            if (block != null)
            {
                block.Parent = this;
                Blocks.Add(block);
            }
        }
    
        // Get a variable.
        public Variable GetVariable(string name)
        {
            BlockBase block = this;
            do
            {
                Variable variable = block.Variables.Where(x => x.Name == name).FirstOrDefault();
                if (variable != null)
                {
                    return variable;
                }
                block = block.Parent;
            } while (block != null);
            return null;
        }
    
        // Checks if variable is in scope.
        protected bool IsInScope(XElement xElm, string varName)
        {
            // Traverses the tree and searches for variables in parent blocks and before self
            // so that we don't get variables defined after self.
            var xCurrentElm = xElm;
            do
            {
                var variable = 
                    xCurrentElm
                    .ElementsBeforeSelf()
                    .Where(x => x.Name.LocalName == "var" && x.Attribute("name").Value == varName)
                    .FirstOrDefault();
                if (variable != null) return true;
                xCurrentElm = xCurrentElm.Parent;
            } while (xCurrentElm != null);
            return false;
        }
    }
    
    // Block class.
    class Block : BlockBase
    {
        public Block(XElement xBlock)
            : base(xBlock)
        {
    
        }
    }
    
