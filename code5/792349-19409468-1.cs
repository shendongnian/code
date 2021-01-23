    using System;
    using System.Text;
    namespace Microsoft.Xna.Framework.Graphics
    {
        public class SpriteBatch : GraphicsResource
        {
            readonly SpriteBatcher _batcher;
                SpriteSortMode _sortMode;
                BlendState _blendState;
                SamplerState _samplerState;
                DepthStencilState _depthStencilState; 
                RasterizerState _rasterizerState;                
                Effect _effect;
                bool _beginCalled;
                Effect _spriteEffect;
                readonly EffectParameter _matrixTransform;
                readonly EffectPass _spritePass;
                Matrix _matrix;
                Rectangle _tempRect = new Rectangle (0,0,0,0);
                Vector2 _texCoordTL = new Vector2 (0,0);
                Vector2 _texCoordBR = new Vector2 (0,0);
                public SpriteBatch (GraphicsDevice graphicsDevice)
                {
                    if (graphicsDevice == null) 
                    {
                            throw new ArgumentException ("graphicsDevice");
                    }        
                    this.GraphicsDevice = graphicsDevice;
                    // Use a custom SpriteEffect so we can control the transformation matrix
                    _spriteEffect = new Effect(graphicsDevice, SpriteEffect.Bytecode);
                    _matrixTransform = _spriteEffect.Parameters["MatrixTransform"];
                    _spritePass = _spriteEffect.CurrentTechnique.Passes[0];
                    _batcher = new SpriteBatcher(graphicsDevice);
                    _beginCalled = false;
                }
                public void Begin ()
                {
                    Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);        
                }
                public void Begin (SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect, Matrix transformMatrix)
                {
                    if (_beginCalled)
                        throw new InvalidOperationException("Begin cannot be called again until End has been successfully called.");
                    // defaults
                    _sortMode = sortMode;
                    _blendState = blendState ?? BlendState.AlphaBlend;
                    _samplerState = samplerState ?? SamplerState.LinearClamp;
                    _depthStencilState = depthStencilState ?? DepthStencilState.None;
                    _rasterizerState = rasterizerState ??   RasterizerState.CullCounterClockwise;
                    _effect = effect;
                        
                    _matrix = transformMatrix;
                    // Setup things now so a user can chage them.
                    if (sortMode == SpriteSortMode.Immediate)
                        Setup();
                    _beginCalled = true;
                }
                public void Begin (SpriteSortMode sortMode, BlendState blendState)
                {
                    Begin (sortMode, blendState, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);                        
                }
                public void Begin (SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState)
                {
                    Begin (sortMode, blendState, samplerState, depthStencilState, rasterizerState, null, Matrix.Identity);        
                }
                public void Begin (SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect)
                {
                    Begin (sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, Matrix.Identity);                        
                }
                public void End ()
                {        
                    _beginCalled = false;
                    if (_sortMode != SpriteSortMode.Immediate)
                            Setup();
    #if PSM   
            GraphicsDevice.BlendState = _blendState;
            _blendState.ApplyState(GraphicsDevice);
    #endif
            
            _batcher.DrawBatch(_sortMode);
        }
