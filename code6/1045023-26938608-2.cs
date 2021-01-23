    var n = (int) Math.Sqrt(pads.Length);
    int i = 0, j = 0, k = 0;
    for(i = 0; i < n; i++){
       k = i;
       AnimatePad(ref beginMs, spd, pads[k], toColor);
       for(j = 0; j < i; j++){
          k += n-1;          
          AnimatePad(ref beginMs, spd, pads[k], toColor);
       }
       beginMs += interval;
    }
    for(i = n-2; i >= 0; i--){       
       k = (n-i)*n - 1;
       AnimatePad(ref beginMs, spd, pads[k], toColor);
       for(j = 0; j < i; j++){
          k += n-1;
          AnimatePad(ref beginMs, spd, pads[k], toColor);
       }
       beginMs += interval;
    }
