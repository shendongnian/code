    using Microsoft.Xna.Framework.Audio;
    
    using Microsoft.Xna.Framework.Media;
    
    using Microsoft.Xna.Framework;
    
    static Stream stream1 = TitleContainer.OpenStream("soundeffect.wav");
    
    static SoundEffect sfx = SoundEffect.FromStream(stream1);
    
    static SoundEffectInstance soundEffect = sfx.CreateInstance();
