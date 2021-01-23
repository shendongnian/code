    public class LetterData
    {
    	public DirectionsType[] Directions;
    	public RotationsType[] Rotations;
    }
    
    LetterData[] myVar = new LetterData[25];
    ...
    myVar[i].Directions = new DirectionsType[n];
    ...
    myVar[i].Directions[k] = value;
