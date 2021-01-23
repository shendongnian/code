    using UnityEngine;
    using System.Collections;
    [System.Serializable]
    public class Inventory : MonoBehaviour 
    {
        public GUISkin mainDesignSkin;
        public GUISkin craftDesignSkin;
        public bool enableCraftingMenu = true;
        public int craftSlot1;
        public int craftSlot2;
        public int craftResult; //Make this private users do not need to see this it will clutter editor.
        [SerializeField] 
        public int [] slotContents;
    }
